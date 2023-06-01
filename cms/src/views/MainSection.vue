<!-- בס׳ד -->
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
                  v-model="primaryImage"
                  label="Primary Image"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row justify="center">
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="primaryLink"
                  label="Primary Link"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="primaryLinkText"
                  label="Primary Link Text"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row justify="center">
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="primaryButton"
                  label="Primary Button"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="primaryButtonText"
                  label="Primary Button Text"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row justify="center">
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="secondaryButton"
                  label="Secondary Button"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="secondaryButtonText"
                  label="Secondary Button Text"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-btn type="submit" color="#26547C" @click="makeChanges" block class="mt-2 custom-button">
              Edit
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


const primaryImage = ref('')
const primaryLink = ref('')
const primaryLinkText = ref('')
const primaryButton = ref('')
const primaryButtonText = ref('')
const secondaryButton = ref('')
const secondaryButtonText = ref('')

onMounted(async () => {
    const data = await getSection('main')
    console.log(data)
    primaryImage.value = data.primaryImage
    console.log(primaryImage.value)
    primaryLink.value = data.primaryLink.link
    primaryLinkText.value = data.primaryLink.text
    primaryButton.value = data.primaryButton.link
    primaryButtonText.value = data.primaryButton.text
    secondaryButton.value = data.secondaryButton.link
    secondaryButtonText.value = data.secondaryButton.text
})


const makeChanges = async () => {
    const data = {
        "primaryImage": primaryImage.value,
        "primaryLink": {
            "link": primaryLink.value,
            "text": primaryLinkText.value
        },
        "primaryButton": {
            "link": primaryButton.value,
            "text": primaryButtonText.value
        },
        "secondaryButton": {
            "link": secondaryButton.value,
            "text": secondaryButtonText.value
        },
    }
    console.log("the data is", JSON.stringify(data))
    await addSection('homepageSections/main', data)
}

</script>

<style scoped>
.custom-button {
  color: white; /* Change this to your desired color */
}

</style>