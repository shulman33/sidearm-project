<!-- בס׳ד -->
<template>

    <SidebarNav>
        <h1>footer</h1>
    </SidebarNav>


</template>

<script setup>
import {ref} from 'vue'
import SidebarNav from '../components/SidebarNav.vue';

const footer = ref({
    "links": {
        "link1": {
            "link": "",
            "text": ""
        },
        "link2": {
            "link": "",
            "text": ""
        },
        "link3": {
            "link": "",
            "text": ""
        }
    },
    "image": ""

})

</script>