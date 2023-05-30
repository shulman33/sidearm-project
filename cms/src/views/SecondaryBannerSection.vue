<!-- בס׳ד -->
<template>

    <SidebarNav>
        <h1>Secondary Banner</h1>
    </SidebarNav>


</template>

<script setup>
import {ref} from 'vue'
import SidebarNav from '../components/SidebarNav.vue';

const secondarBanner = ref({
    "title1": {
        "link": "",
        "text": ""
    },
    "title2": {
        "link": "",
        "text": ""
    },
    "title3": {
        "link": "",
        "text": ""
    },
    "title4": {
        "link": "",
        "text": ""
    },
})

</script>