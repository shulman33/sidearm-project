<!-- בס׳ד -->
<template>

    <SidebarNav>
        <h1>headlinesr</h1>
    </SidebarNav>


</template>

<script setup>
import {ref} from 'vue'
import SidebarNav from '../components/SidebarNav.vue';

const headlines = ref({
    "primaryTitle": "",
    "entry1": {
        "link": "",
        "text": ""
    },
    "entry2": {
        "link": "",
        "text": ""
    },
    "entry3": {
        "link": "",
        "text": ""
    },
    "entry4": {
        "link": "",
        "text": ""
    },
    "entry5": {
        "link": "",
        "text": ""
    },
    "entry6": {
        "link": "",
        "text": ""
    }
})

</script>