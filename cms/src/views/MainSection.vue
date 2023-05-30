<!-- בס׳ד -->
<template>

    <SidebarNav>
        <h1>main</h1>
    </SidebarNav>


</template>

<script setup>
import {ref} from 'vue'
import SidebarNav from '../components/SidebarNav.vue';

const main = ref({
    "primaryImage": "",
    "primaryLink": {
        "link": "",
        "text": ""
    },
    "primaryButton": {
        "link": "",
        "text": ""
    },
    "secondaryButton": {
        "link": "",
        "text": ""
    },

})

</script>