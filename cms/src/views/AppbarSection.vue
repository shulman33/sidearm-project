<template>
    <v-sheet width="85%" class="mx-auto">
      <v-form @submit.prevent>
        <v-row>
          <v-col
            cols="12"
            sm="4"
            v-for="(title, index) in appbarTitles"
            :key="index"
          >
            <v-text-field
              v-model="appbarTitles[index]"
              :label="appbarTitles[index]"
            ></v-text-field>
          </v-col>
        </v-row>
        <v-btn type="submit" block class="mt-2">Make Changes</v-btn>
      </v-form>
    </v-sheet>
</template>



<script setup>
//TODO: Add "add title" button and change DB schema and api to allow for more titles
//TODO: Add "remove title" button and change DB schema and api to allow deleting titles
import { ref, onMounted } from 'vue'
import SidebarNav from '../components/SidebarNav.vue'
import { patchField, getSection, addSection } from '../API/endpoints'

const appbarTitles = ref([])

onMounted(async () => {
  const sectionData = await getSection('app-bar')
  appbarTitles.value = sectionData.titles
})
</script>
