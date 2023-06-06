<template>
    <v-app-bar color="#235591">
        <v-img :src="image" max-height="50px"></v-img>
        <v-toolbar-items color="white">
            <v-btn v-for="title in titles" :key="title">
                {{ title }}
            </v-btn>
        </v-toolbar-items>
    </v-app-bar>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { getSection } from '../API/endpoints.js'

const titles = ref([]);
const image = ref('https://dxbhsrqyrr690.cloudfront.net/sidearm.nextgen.sites/yumacs.com/images/responsive_2021/logo-secondary.png');

onMounted(async () => {
    const sections = await getSection("app-bar");
    titles.value = sections.titles;
});
</script>
