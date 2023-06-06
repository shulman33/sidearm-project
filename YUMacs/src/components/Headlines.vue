<template>
    <div class="d-flex justify-center align-center">
        <v-sheet
        class="mt-14"
        width="20%"
        :elevation="6"
        color="#F8F8FF"
        >
            <v-container>
                <v-row>
                    <v-col cols="12" md="12">
                        <h2>{{ headlines.primaryTitle }}</h2>
                    </v-col>
                </v-row>

                <v-row v-for="headline in headlines.entries" :key="headline.text">
                    <v-col cols="12" md="12">
                        <a :href="headline.link">
                            <h3>{{ headline.text }}</h3>
                        </a>
                    </v-col>
                </v-row>

            </v-container>
    
    
        </v-sheet>
    </div>

</template>

<script setup>
import { ref, onMounted } from 'vue';
import { getSection } from '../API/endpoints.js'

const headlines = ref({});

onMounted(async () => {
    headlines.value = await getSection("headlines");
    console.log("headlines", headlines.value);
});

</script>