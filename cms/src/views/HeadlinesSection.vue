<!-- בס׳ד -->
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
                    v-model="primaryTitle"
                    label="Primary Title"
                    ></v-text-field>
                </v-col>
            </v-row>
            <v-btn type="submit" @click="editPrimaryTitle" :color="editColor" block class="mt-2 custom-button">
                Edit
                <v-icon right>{{ editIcon }}</v-icon>
            </v-btn>
          </v-container>
        </v-form>
      </v-sheet>

        <v-sheet
            class="mt-14"
            width="1000"
            :elevation="6"
            color="#F8F8F8"
            >

            <v-container>
                <v-row justify="center">
                    <v-col cols="12" sm="12">
                        <v-list lines="3">
                            <div v-for="(entry, index) in entries" :key="index">
                                <v-list-item v-model="entries">
                                    <div class="d-flex justify-space-between align-center w-100">
                                        <div class="flex-grow-1 overflow-hidden">
                                            <v-list-item-title class="text-truncate">{{ entry.text }}</v-list-item-title>
                                            <v-list-item-subtitle class="text-truncate">
                                                <a :href="entry.link" target="_blank" class="blue-link">{{ entry.link }}</a>
                                            </v-list-item-subtitle>
                                        </div>
                                        <div class="d-flex">
                                            <v-list-item-action>
                                                <v-btn icon size="x-small">
                                                    <v-icon color="blue">mdi-pencil</v-icon>
                                                </v-btn>
                                            </v-list-item-action>

                                            <v-list-item-action>
                                                <v-btn icon size="x-small">
                                                    <v-icon color="red">mdi-delete</v-icon>
                                                </v-btn>
                                            </v-list-item-action>
                                        </div>
                                    </div>
                                </v-list-item>

                                <!-- Add divider after each item except the last one -->
                                <v-divider v-if="index < entries.length - 1"></v-divider>
                            </div>
                        </v-list>
                    </v-col>
                </v-row>
            </v-container>
        </v-sheet>
    </div>
</template>

<script setup>
import { ref, onMounted} from 'vue'
import { getSection, addSection} from '../API/endpoints.js'


const primaryTitle = ref("")
const entries = ref({})
const editColor = ref('#26547C');
const editIcon = ref('');

onMounted(async () => {
    const data = await getSection('headlines')
    console.log(data)
    primaryTitle.value = data.primaryTitle
    console.log("primaryTitle", primaryTitle.value)
    entries.value = data.entries
    console.log("entries", entries.value)
})

const editPrimaryTitle = async () => {
    const section = {
        primaryTitle: primaryTitle.value
    }
    try{
        await addSection("homepageSections/headlines", section)
        editColor.value = '#4CAF50';
        editIcon.value = 'mdi-check';

        const data = await getSection("headlines")
        primaryTitle.value = data.primaryTitle
    }catch(err){
        editColor.value = '#FF3333';
        editIcon.value = 'mdi-close';
    }
    setTimeout(() => {
    editColor.value = '#26547C';
    editIcon.value = '';
    }, 2000);
}


</script>

<style scoped>
.text-truncate {
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.flex-grow-1 {
    flex-grow: 1;
}

.custom-button {
  color: white; /* Change this to your desired color */
}

.blue-link {
    color: blue;
}


</style>