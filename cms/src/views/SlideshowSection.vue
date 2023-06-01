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
                    <v-btn type="submit" color="#26547C" @click="addSlide" block class="mt-2 custom-button">
                        Add Slide
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
    </v-container>
</v-sheet>



    </div>

</template>

<script setup>
import { ref, onMounted} from 'vue'
import { getSection, addSection, deleteSection } from '../API/endpoints.js'

const newSlide = ref('')
const slides = ref([])
const editingIndex = ref(null) // Track index of slide being edited

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

    await addSection('homepageSections/slideshow', data)

    newSlide.value = ''

    const newData = await getSection('slideshow')
    slides.value = newData
}

const deleteSlide = async (index) => {
    slides.value.splice(index, 1)
    await deleteSection('homepageSections/slideshow', {slides: slides.value})

    const data = await getSection('slideshow')
    slides.value = data
}

const editSlide = (index) => {
    editingIndex.value = index
}

const saveSlide = async (index) => {
    await addSection('homepageSections/slideshow', {slides: slides.value})
    editingIndex.value = null // Exit editing mode

    const data = await getSection('slideshow')
    slides.value = data
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
