<!-- בס׳ד -->
<template>
    <div class="d-flex justify-center align-center">
      <v-container v-if="dataLoaded">
          <v-row>
          <v-col cols="12" sm="12">
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
                          v-model="mainSection.primaryImage"
                          label="Primary Image"
                          ></v-text-field>
                      </v-col>
                  </v-row>
                  <v-row>
                    <v-col cols="12" sm="6">
                      <v-text-field
                        v-model="mainSection.primaryLink.link"
                        label="Primary Link Text"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="6">
                      <v-text-field
                        v-model="mainSection.primaryLink.text"
                        label="Primary Link Text"
                      ></v-text-field>
                    </v-col>
                  </v-row>

                  <v-row>
                    <v-col cols="12" sm="6">
                      <v-text-field
                        v-model="mainSection.primaryButton.link"
                        label="Primary Link Text"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="6">
                      <v-text-field
                        v-model="mainSection.primaryButton.text"
                        label="Primary Link Text"
                      ></v-text-field>
                    </v-col>
                  </v-row>

                  <v-row>
                    <v-col cols="12" sm="6">
                      <v-text-field
                        v-model="mainSection.secondaryButton.link"
                        label="Primary Link Text"
                      ></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="6">
                      <v-text-field
                        v-model="mainSection.secondaryButton.text"
                        label="Primary Link Text"
                      ></v-text-field>
                    </v-col>
                  </v-row>
                  <v-btn type="submit" @click="editFields" :color="editColor1" block class="mt-2 custom-button">
                      Edit
                      <v-icon right>{{ editIcon1 }}</v-icon>
                  </v-btn>
                </v-container>
              </v-form>
            </v-sheet>
          </v-col>
        </v-row>

      </v-container>
      
      
    </div>
  </template>
  

<script setup>
import {ref} from 'vue'
import { getSection, patchSection } from '../API/endpoints.js'
import { onMounted } from 'vue';


const mainSection = ref({})
const dataLoaded = ref(false)


const editColor1 = ref('#26547C');
const editIcon1 = ref('');


onMounted(async () => {
    const data = await getSection('main')
    console.log("data", data)
    mainSection.value = data 
    dataLoaded.value = true 
    console.log(mainSection.value)
})


const editFields = async () => {
    console.log("form data", mainSection.value)

    try{
      await patchSection('main', mainSection.value)
      editColor1.value = '#4CAF50';
      editIcon1.value = 'mdi-check';

      const data = await getSection('main')
      mainSection.value = data
    }catch(err){
      editColor1.value = '#F44336';
      editIcon1.value = 'mdi-close';
    }
    setTimeout(() => {
      editColor1.value = '#26547C';
      editIcon1.value = '';
    }, 2000);

    
}


</script>

<style scoped>
.custom-button {
  color: white; /* Change this to your desired color */
}

</style>