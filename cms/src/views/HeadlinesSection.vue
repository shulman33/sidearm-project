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
            <v-btn type="submit" @click="saveChanges" :color="editColor1" block class="mt-2 custom-button">
                Edit
                <v-icon right>{{ editIcon1 }}</v-icon>
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

            <v-container v-if="dataLoaded">
                <v-row justify="center">
                    <v-col cols="12" sm="12">
                        <v-list lines="3">
                            <div v-for="(entry, index) in entries" :key="index">
                                <v-list-item v-model="entries">
                                    <div class="d-flex justify-space-between align-center w-100">
                                        <div v-if="editingIndex !== index" class="flex-grow-1 overflow-hidden">
                                            <v-list-item-title class="text-truncate">{{ entry.text }}</v-list-item-title>
                                            <v-list-item-subtitle class="text-truncate">
                                                <a :href="entry.link" target="_blank" class="blue-link">{{ entry.link }}</a>
                                            </v-list-item-subtitle>
                                        </div>
                                        <div v-else class="flex-grow-1">
                                            <v-text-field v-model="entries[index].text" label="Edit Headline Title" full-width></v-text-field>
                                            <v-text-field v-model="entries[index].link" label="Edit Headline Link" full-width></v-text-field>
                                        </div>
                                        <div class="d-flex">
                                            <v-list-item-action>
                                                <v-btn icon size="x-small" @click="editingIndex !== index ? editEntry(index) : saveEntry(index)">
                                                    <v-icon color="blue">mdi-pencil</v-icon>
                                                </v-btn>
                                            </v-list-item-action>

                                            <v-list-item-action>
                                                <v-btn icon size="x-small" @click="deleteHeadline(index)">
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
                <v-btn type="submit" @click="saveChanges" :color="editColor2" block class="mt-2 custom-button">
                      Edit
                      <v-icon right>{{ editIcon2 }}</v-icon>
                  </v-btn>
            </v-container>
        </v-sheet>

        <v-sheet
            class="mt-14"
            width="1000"
            :elevation="6"
            color="#F8F8F8"
        >
            <v-form @submit.prevent>
                <v-container>
                    <v-row justify="center">
                        <v-col cols="12" sm="6">
                            <v-text-field
                            v-model="newEntry.text"
                            label="Headline Text"
                            ></v-text-field>
                        </v-col>

                        <v-col cols="12" sm="6">
                            <v-text-field
                            v-model="newEntry.link"
                            label="Headline Link"
                            ></v-text-field>
                        </v-col>

                        
                    </v-row>
            <v-btn type="submit" @click="addNewHeadline" :color="addColor" block class="mt-2 custom-button">
                Add New Headline
                <v-icon right>{{ addIcon }}</v-icon>
            </v-btn>
                </v-container>
            </v-form>
            
            
        </v-sheet>
    </div>
</template>

<script setup>
import { ref, onMounted} from 'vue'
import { getSection, addSection, deleteSection, patchSection} from '../API/endpoints.js'


const primaryTitle = ref("")
const entries = ref({})
const editColor1 = ref('#26547C');
const editIcon1 = ref('');

const editColor2 = ref('#26547C');
const editIcon2 = ref('');

const addColor = ref('#26547C');
const addIcon = ref('');

const editingIndex = ref(null) // Track index of slide being edited

const dataLoaded = ref(false)

const newEntry = ref({
    text: "",
    link: ""
})


onMounted(async () => {
    const data = await getSection('headlines')
    console.log(data)
    primaryTitle.value = data.primaryTitle
    console.log("primaryTitle", primaryTitle.value)
    entries.value = data.entries
    console.log("entries", entries.value)
    dataLoaded.value = true
})

const editEntry = (index) => {
    editingIndex.value = index
}

const deleteHeadline = async (index) => {
    console.log("delete index", index)

    entries.value.splice(index, 1)

    const payload = {
        primary_title: primaryTitle.value,
        entries: entries.value
    }

    try{
        await patchSection("headlines", payload)

        const data = await getSection("headlines")
        entries.value = data.entries

    }catch(err){
        alert("Error deleting headline")
    }
}

const saveChanges = async () => {
    console.log("editFields", entries.value)

    const section = {
        primary_title: primaryTitle.value,
        entries: entries.value
    }

    try{
        await patchSection("headlines", section)
        editColor2.value = '#4CAF50';
        editIcon2.value = 'mdi-check';

        const data = await getSection("headlines")
        entries.value = data.entries

        dataLoaded.value = true

        editingIndex.value = null
    }catch(err){
        editColor2.value = '#FF3333';
        editIcon2.value = 'mdi-close';
    }
    setTimeout(() => {
        editColor2.value = '#26547C';
        editIcon2.value = '';
        }, 2000);
}

const addNewHeadline = async () => {
    const section = {
        entries: newEntry
    }

    console.log("section", section.value)

    // add new headline to array
    entries.value.push(newEntry.value)

    console.log("after push", entries.value)

    const payload = {
        primary_title: primaryTitle.value,
        entries: entries.value
    }

    console.log("payload", payload)

    try{
        await patchSection("headlines", payload)
        addColor.value = '#4CAF50';
        addIcon.value = 'mdi-check';

        const data = await getSection("headlines")
        entries.value = data.entries

        newEntry.value = {
            text: "",
            link: ""
        }

    }catch(err){
        addColor.value = '#FF3333';
        addIcon.value = 'mdi-close';
    }
    setTimeout(() => {
        addColor.value = '#26547C';
        addIcon.value = '';
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