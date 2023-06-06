<template>
    <div class="d-flex justify-center align-center">
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
                    v-model="image"
                    label="Bottom Banner Image"
                    ></v-text-field>
                </v-col>
            </v-row>
            <v-btn type="submit" @click="makeChanges" :color="editColor" block class="mt-2 custom-button">
                Edit
                <v-icon right>{{ editIcon }}</v-icon>
            </v-btn>
          </v-container>
        </v-form>
      </v-sheet>
    </div>
</template>

<script setup>
import {ref} from 'vue'
import { getSection, addSection} from '../API/endpoints.js'
import { onMounted } from 'vue';

const image = ref("")
const editColor = ref('#26547C');
const editIcon = ref('');

onMounted(async () => {
    const section = await getSection("bottom-banner")
    image.value = section.image
})


const makeChanges = async () => {
    const section = {
        image: image.value
    }
    try{
        await addSection("homepageSections/bottomBanner", section)
        editColor.value = '#4CAF50';
        editIcon.value = 'mdi-check';

        const data = await getSection("bottom-banner")
        image.value = data.image
    }catch(err){
        editColor.value = '#FF3333';
        editIcon.value = 'mdi-close';
    }
    setTimeout(() => {
    editColor.value = '#26547C';
    editIcon.value = '';
  }, 3000);
}
</script>

<style scoped>
.custom-button {
  color: white; /* Change this to your desired color */
}

</style>