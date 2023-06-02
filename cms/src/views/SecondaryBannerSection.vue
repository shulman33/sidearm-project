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
                <v-row justify="center" 
                    v-for="(tile, index) in tiles"
                    :key="index"
                >
                    <v-col cols="12" sm="6">
                        <v-text-field
                        v-model="tile.link"
                        :label="`Link${index.replace( /^\D+/g, '')}`"
                        ></v-text-field>
                    </v-col>

                    <v-col cols="12" sm="6">
                        <v-text-field
                        v-model="tile.image"
                        :label="`Image${index.replace( /^\D+/g, '')}`"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn type="submit" @click="editTiles" :color="editColor" block class="mt-2 custom-button">
                    Edit
                <v-icon right>{{ editIcon }}</v-icon>
              </v-btn>
            </v-container>
        </v-form>
      </v-sheet>
    </div>
</template>

<script setup>
import { ref, onMounted} from 'vue'
import { getSection, addSection} from '../API/endpoints.js'


const tiles = ref([])

const editColor = ref('#26547C');
const editIcon = ref('');

onMounted(async () => {
    const data = await getSection('secondary_banner')
    console.log(data)
    tiles.value = data
    console.log(tiles.value)
})

const editTiles = async () => {
    const data = tiles.value
    console.log("data", data)
    try{
        await addSection('homepageSection/secondaryBanner', data)
        editColor.value = '#26547C'
        editIcon.value = 'mdi-check'
    }catch (err) {
        editColor.value = '#FF3333';
        editIcon.value = 'mdi-close';
        console.log(err)
    }
    
    setTimeout(() => {
        editColor.value = '#26547C'
        editIcon.value = ''
    }, 2000)
}

</script>

<style scoped>
.custom-button {
  color: white; 
}

</style>