<template>

<div class="d-flex justify-center align-center">
        <v-sheet
        class="mt-14"
        width="50%"
        :elevation="6"
        color="#F8F8FF"
      >
            <v-container v-if="hasLoaded">
                <v-row>
                    <v-col cols="12" md="12">
                        <v-img :src="mainSection.primaryImage" max-height="400px"></v-img>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols="12" md="12">
                        <a :href="mainSection.primaryLink.link">
                            <v-card-title class="text-center">
                                <h1>{{ mainSection.primaryLink.text }}</h1>
                            </v-card-title>
                        </a>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col cols="12" md="6">
                        <v-btn>
                            <a :href="mainSection.primaryButton.link">
                                <h1>{{ mainSection.primaryButton.text }}</h1>
                            </a>
                        </v-btn>
                    </v-col>
                    <v-col cols="12" md="6">
                        <v-btn>
                            <a :href="mainSection.secondaryButton.link">
                                <h1>{{ mainSection.secondaryButton.text }}</h1>
                            </a>
                        </v-btn>
                    </v-col>
                </v-row>
            </v-container>
        </v-sheet>

</div>

</template>

<script setup>
    import { ref, onMounted } from 'vue';
    import { getSection } from '../API/endpoints.js'

    const mainSection = ref({});

    const hasLoaded = ref(false);

    onMounted(async () => {
        mainSection.value = await getSection("main");
        console.log("mainsections", mainSection.value);
        hasLoaded.value = true;
    });
</script>