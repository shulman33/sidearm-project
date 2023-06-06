<template>
    <v-container>
        <MainSection />
        <Headlines />   
    </v-container>
    
</template>

<script setup>
import { ref, onMounted } from 'vue';
import MainSection from '../components/MainSection.vue';
import Headlines from '../components/Headlines.vue';

</script>