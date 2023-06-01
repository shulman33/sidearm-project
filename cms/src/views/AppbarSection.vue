<template>
  <div class="flex-container">
    <v-sheet 
      class="mt-14"
      width="400" 
      :elevation="6"
      color="#F8F8FF"
    >
      <v-form >
        <v-text-field
          v-for="(title, index) in appbarTitles"
            :key="index"
            v-model="appbarTitles[index]"
            :label="title"
        ></v-text-field>

        <v-btn type="submit" @click="editTitles" color="#26547C" block class="mt-2 custom-button">Edit</v-btn>
      </v-form>
    </v-sheet>

    <v-sheet 
      class="mt-14 ml-16 content-width"
      :elevation="6"
      color="#F8F8FF"
    >
      <v-checkbox
        v-for="(title, index) in appbarTitles"
        :label="title"
        color="#26547C"
        :key="'checkbox-' + index"
      ></v-checkbox>
      <v-btn type="submit" color="#FF3333" block class="mt-2 custom-button">Delete</v-btn>
    </v-sheet>
  </div>
  <v-sheet 
  class="mt-14"
      :elevation="6"
      color="#F8F8FF"
    >
    <v-form >
        <v-text-field
          v-model="addTitleValue"
          label="Add Title"
        ></v-text-field>
        <v-btn type="submit" @click="addTitle" color="#26547C" block class="mt-2 custom-button">Add Title</v-btn>
      </v-form>
    </v-sheet>
</template>


<script setup>
import { ref, onMounted } from 'vue'
import { getSection, addSection, deleteSection } from '../API/endpoints'

const appbarTitles = ref({});
const newTitles = ref([])
const succesfullEdit = ref(false)
const succesfullAdd = ref(false)
const sucessfullDelete = ref(false)

const addTitleValue = ref('')

const addTitle = async () => {
  const keys = Object.keys(appbarTitles.value);

  // Extract numbers from the keys and find the maximum.
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

  await addSection('homepageSections.appBar/titles', data);
}


const editTitles = async () => {
  await addSection('homepageSections.appBar/titles', appbarTitles.value)
}

onMounted(async () => {
  const sectionData = await getSection('app-bar')
  appbarTitles.value = sectionData.titles
  console.log("--------------------")
  console.log(JSON.stringify(appbarTitles.value))
})


</script>

<style scoped>
.custom-button {
  color: white; /* Change this to your desired color */
}
.flex-container {
  display: flex;
}

.content-width {
  width: auto;
  min-width: 200px; /* Adjust this value according to your needs */
}
</style>


