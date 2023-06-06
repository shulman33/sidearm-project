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
                                v-model="newSlide"
                                label="New Slide"
                                ></v-text-field>
                        </v-col>
                    </v-row>
                    <v-btn type="submit" @click="addSlide" :color="editColor1" block class="mt-2 custom-button">
                        Add Slide
                <v-icon right>{{ editIcon1 }}</v-icon>
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
                <v-list-item-group v-model="slides">
                    <v-list-item v-for="(slide, index) in slides" :key="index">
                        <div class="d-flex justify-space-between align-items-center w-100">
                            <div v-if="editingIndex !== index" class="flex-grow-1 truncate-text">
                                <v-list-item-title>
                                    <a :href="slide" target="_blank" class="blue-link">{{ slide }}</a>
                                </v-list-item-title>

                            </div>
                            <div v-else class="flex-grow-1">
                                <v-text-field v-model="slides[index]" label="Edit Slide" full-width></v-text-field>
                            </div>
                            <div class="d-flex align-items-center">
                                <v-list-item-action>
                                    <v-btn icon size="x-small" @click="editingIndex !== index ? editSlide(index) : saveSlide(index)">
                                        <v-icon color="blue">mdi-pencil</v-icon>
                                    </v-btn>
                                </v-list-item-action>
                                <v-list-item-action>
                                    <v-btn icon size="x-small" @click="deleteSlide(index)">
                                        <v-icon color="red">mdi-delete</v-icon>
                                    </v-btn>
                                </v-list-item-action>
                            </div>
                        </div>
            </v-list-item>
        </v-list-item-group>
            </v-col>
        </v-row>
        <v-btn type="submit" @click="saveChanges" :color="editColor2" block class="mt-2 custom-button">
                Save Changes
                <v-icon right>{{ editIcon2 }}</v-icon>
        </v-btn>
    </v-container>
</v-sheet>



    </div>

</template>

<script setup>
import { ref, onMounted} from 'vue'
import { getSection, addSection, deleteSection, patchSection } from '../API/endpoints.js'

const newSlide = ref('')
const slides = ref([])
const editingIndex = ref(null) // Track index of slide being edited

const editColor1 = ref('#26547C');
const editIcon1 = ref('');

const editColor2 = ref('#26547C');
const editIcon2 = ref('');

onMounted(async () => {
    const data = await getSection('slideshow')
    slides.value = data
})

const addSlide = async () => {
    const keys = Object.keys(slides.value);
    console.log("keys", keys)

    const maxNumber = keys.reduce((max, key) => {
        const number = parseInt(key.replace('slide', ''), 10);
        return Math.max(max, number);
    }, 0);

    const slideNumber = maxNumber + 1;
    console.log("slideNumber", slideNumber)

    const data = {
        [`slide${slideNumber}`]: newSlide.value
    };

    console.log("data", data)
    try{
        await addSection('homepageSections/slideshow', data)
        editColor1.value = '#4CAF50';
        editIcon1.value = 'mdi-check';

        newSlide.value = ''

        const newData = await getSection('slideshow')
        slides.value = newData
    } catch (error) {
        editColor1.value = '#FF0000';
        editIcon1.value = 'mdi-close';
    }
    setTimeout(() => {
    editColor1.value = '#26547C';
    editIcon1.value = '';
    }, 2000);
    

    
}

const deleteSlide = async (index) => {
    console.log("delete slide index", index)
    const endpoint = `homepageSections/slideshow.${index}`
    await deleteSection(endpoint)

    const data = await getSection('slideshow')
    slides.value = data
}

const editSlide = (index) => {
    editingIndex.value = index
}

const saveChanges = async () => {

    console.log("slides", slides.value)
    try{
        await patchSection('slideshow', slides.value)
        editingIndex.value = null // Exit editing mode
        editColor2.value = '#4CAF50';
        editIcon2.value = 'mdi-check';

        const data = await getSection('slideshow')
        slides.value = data
    }catch(error){
        editColor2.value = '#FF0000';
        editIcon2.value = 'mdi-close';
    }
    setTimeout(() => {
    editColor2.value = '#26547C';
    editIcon2.value = '';
    }, 2000);
    
}

</script>


<style scoped>
.custom-button {
  color: white; /* Change this to your desired color */
}

.flex-grow-1 {
  flex-grow: 1;
}

.truncate-text {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.blue-link {
    color: blue;
}
</style>
