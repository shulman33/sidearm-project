<template>
  <SidebarNav>
      <v-sheet class="d-flex align-center justify-center">
          <v-container fluid>
              <v-row justify="center">
                  <v-col cols="30" sm="30" md="28">
                      <v-form fast-fail @submit.prevent>
                          <v-text-field
                              v-for="(title, index) in appbarTitles"
                              v-model="appbarTitles[index]"
                              :label="appbarTitles[index]" 
                          ></v-text-field>

                          <v-btn type="submit" color="#26547C" style="color: white" block class="mt-2">Make Changes</v-btn>
                      </v-form>
                  </v-col>
              </v-row>
          </v-container>
      </v-sheet>
  </SidebarNav>
</template>


<script setup>
//TODO: Add "add title" button and change DB schema and api to allow for more titles
//TODO: Add "remove title" button and change DB schema and api to allow deleting titles
import {ref} from 'vue'
import SidebarNav from '../components/SidebarNav.vue'
import { patchField, getSection, addSection } from '../API/endpoints'

const appbarTitles = ref(getSection('app-bar'))
  
</script>