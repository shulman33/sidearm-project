<template>
  
  <div class="d-flex flex-column align-center justify-center">
    <v-sheet
            class="mt-14"
            width="1000"
            :elevation="6"
            color="#F8F8FF"
    >

        <v-form @submit.prevent>
            <v-container>
                <v-row justify="center">
                    <v-col cols="12" sm="12">
                        <v-text-field
                        v-model="addTitleValue"
                        label="New Title"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn type="submit" @click="addTitle" :color="addColor" block class="mt-2 custom-button">
                    Add New Title
                    <v-icon right>{{ addIcon }}</v-icon>
                </v-btn>
            </v-container>
        </v-form>
    </v-sheet>

    <v-sheet
            class="mt-14"
            width="1000"
            :elevation="6"
            color="#F8F8FF"
            >
          
      <v-container>

        <v-row justify="center">
          <v-col cols="12" sm="12">
            <v-list-item-group v-model="appbarTitles">
              
              <v-list-item v-for="(title, index) in appbarTitles" :key="index">
                        <div class="d-flex justify-space-between align-items-center w-100">
                            <div v-if="editingIndex !== index" class="flex-grow-1 truncate-text">
                                <v-list-item-title>
                                    {{ title }}
                                </v-list-item-title>

                            </div>
                            <div v-else class="flex-grow-1">
                                <v-text-field v-model="appbarTitles[index]" label="Edit Title" full-width></v-text-field>
                            </div>
                            <div class="d-flex align-items-center">
                                <v-list-item-action>
                                    <v-btn icon size="x-small" @click="editingIndex !== index ? editSlide(index) : saveSlide(index)">
                                        <v-icon color="blue">mdi-pencil</v-icon>
                                    </v-btn>
                                </v-list-item-action>
                                <v-list-item-action>
                                    <v-btn icon size="x-small" @click="deleteTitle(index)">
                                        <v-icon color="red">mdi-delete</v-icon>
                                    </v-btn>
                                </v-list-item-action>
                            </div>
                        </div>
            </v-list-item>
            </v-list-item-group>
          </v-col>
        </v-row>
        <v-btn type="submit" @click="saveChanges" :color="editColor" block class="mt-2 custom-button">
                Save Changes
                <v-icon right>{{ editIcon }}</v-icon>
        </v-btn>
      </v-container>      
    </v-sheet>
  </div>
</template>


<script setup>
import { ref, onMounted, computed } from 'vue'
import { getSection, addSection, deleteSection, patchSection } from '../API/endpoints'

const appbarTitles = ref({});
const checkboxStates = ref([]);

const editColor = ref('#26547C');
const editIcon = ref('');

const addColor = ref('#26547C');
const addIcon = ref('');

const addTitleValue = ref('')

const editingIndex = ref(null) // Track index of slide being edited

const editSlide = (index) => {
    editingIndex.value = index
}

const addTitle = async () => {
  const keys = Object.keys(appbarTitles.value);

  // Extract numbers from the keys and find the maximum.
  // Ensures an added title will have a unique number.
  const maxNumber = keys.reduce((max, key) => {
    const number = parseInt(key.replace('title', ''), 10);
    return Math.max(max, number);
  }, 0);

  const titleNumber = maxNumber + 1;
  
  console.log("keys", keys);
  console.log("titleNumber", titleNumber);

  const data = {
    [`title${titleNumber}`]: addTitleValue.value
  };

  try {
    await addSection('homepageSections.appBar/titles', data);
    addColor.value = '#4CAF50';
    addIcon.value = 'mdi-check';
  } catch (error) {
    console.error(error);
    addColor.value = '#FF3333';
    addIcon.value = 'mdi-close';
  }
  setTimeout(() => {
    addColor.value = '#26547C';
    addIcon.value = '';
  }, 2000);

  // reload the data
  const sectionData = await getSection('app-bar');
  appbarTitles.value = sectionData.titles;

  addTitleValue.value = '';
}


const deleteTitle = async (index) => {
  console.log("delete title index", index);
  const endpoint = `homepageSections.appBar.titles/${index}`;
  await deleteSection(endpoint);

  const sectionData = await getSection('app-bar');
  appbarTitles.value = sectionData.titles;
}

const saveChanges = async () => {
  console.log("titles", appbarTitles.value);

  try{
    await patchSection('appBar.titles', appbarTitles.value);
    editColor.value = '#4CAF50';
    editIcon.value = 'mdi-check';
    editingIndex.value = null;
  } catch (error) {
    console.error(error);
    editColor.value = '#FF3333';
    editIcon.value = 'mdi-close';
  }
  setTimeout(() => {
    editColor.value = '#26547C';
    editIcon.value = '';
    }, 2000);
}


onMounted(async () => {
  const sectionData = await getSection('app-bar')
  appbarTitles.value = sectionData.titles
  checkboxStates.value = Array(appbarTitleArray.value.length).fill(false);
  console.log("--------------------")
  console.log(JSON.stringify(appbarTitles.value))
})

const appbarTitleArray = computed(() => Object.values(appbarTitles.value));


</script>

<style scoped>
.custom-button {
  color: white; 
}

.flex-grow-1 {
  flex-grow: 1;
}

.truncate-text {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

</style>


