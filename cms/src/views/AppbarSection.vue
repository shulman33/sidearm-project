<template>
  <div class="flex-container">
    <v-sheet 
      class="mt-14"
      width="400" 
      :elevation="6"
      color="#F8F8FF"
    >
      <v-form @submit.prevent>
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
import { ref, onMounted, computed} from 'vue'
import { patchField, getSection, addSection } from '../API/endpoints'

const appbarTitles = ref({});
const newTitles = ref([])
const succesfullEdit = ref(false)
const succesfullAdd = ref(false)
const sucessfullDelete = ref(false)

const addTitleValue = ref('')

const addTitle = async () => {
  const titleNumber = Object.keys(appbarTitles.value).length + 1;
  const data = {
    [`title${titleNumber}`]: addTitleValue.value
  }
  await addSection('homepageSections.appBar/titles', data)
}

const editTitles = async () => {
  const data = newTitles.value.reduce((result, title, index) => {
    if (title !== '') {
      result[`title${index + 1}`] = title;
    }
    return result;
  }, {});
  await addSection('homepageSections.appBar/titles', data)
}



onMounted(async () => {
  const sectionData = await getSection('app-bar')
  appbarTitles.value = sectionData.titles
  console.log(appbarTitles.value)
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


