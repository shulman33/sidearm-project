<!-- בס׳ד -->
<template>

    
    <div class="d-flex justify-center align-center">
        <v-sheet
        class="mt-14"
        width="1000"
        :elevation="6"
        color="#F8F8FF"
      >
        <v-form @submit.prevent >
            <v-container>
                <v-row justify="center">
                    <v-col cols="12" sm="12">
                        <v-text-field
                        v-model="imageLink"
                        label="Footer Image"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" sm="12">
                        <v-text-field
                        v-model="accessibility"
                        label="Accessibility"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" sm="12">
                        <v-text-field
                        v-model="tos"
                        label="Terms of Service"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-row justify="center">
                    <v-col cols="12" sm="12">
                        <v-text-field
                        v-model="privacyPolicy"
                        label="Privacy Policy"
                        ></v-text-field>
                    </v-col>
                </v-row>
                <v-btn type="submit" @click="editFooter" :color="editColor" block class="mt-2 custom-button">
                    Edit
                    <v-icon right>{{ editIcon }}</v-icon>
                </v-btn>
            </v-container>
        </v-form>
      </v-sheet>
    </div>
    


</template>

<script setup>
import { ref, onMounted } from 'vue'
import { getSection, addSection} from '../API/endpoints.js'

const imageLink = ref("")
const accessibility = ref("")
const tos = ref("")
const privacyPolicy = ref("")

const editColor = ref('#26547C');
const editIcon = ref('');


onMounted(async () => {
    const data = await getSection('footer')
    console.log(data)
    imageLink.value = data.image
    accessibility.value = data.accessibility
    tos.value = data.tos
    privacyPolicy.value = data.privacyPolicy
})

const editFooter = async () => {
    const footer = {
        image: imageLink.value,
        accessibility: accessibility.value,
        tos: tos.value,
        privacyPolicy: privacyPolicy.value
    }
    try{
        await addSection("homepageSections/footer", footer)
        editColor.value = '#4CAF50';
        editIcon.value = 'mdi-check';

        const data = await getSection("footer")
        imageLink.value = data.image
        accessibility.value = data.accessibility
        tos.value = data.tos
        privacyPolicy.value = data.privacyPolicy
    }catch(err){
        editColor.value = '#FF3333';
        editIcon.value = 'mdi-close';
    }
    setTimeout(() => {
    editColor.value = '#26547C';
    editIcon.value = '';
    }, 2000);
}


</script>

<style scoped>
.custom-button {
  color: white; 
}

</style>