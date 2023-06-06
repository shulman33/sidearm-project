<script setup>
import {  RouterView } from 'vue-router'
import Appbar from './components/Appbar.vue';

</script>

<template>
  <v-app>

    <v-main class="background">
        <Appbar />
        <RouterView />
    </v-main>
  </v-app>

  <RouterView />
</template>

<style scoped>
.background {
  background-image: url('../public/pattern-randomized.svg');
  background-repeat: no-repeat;
  background-size: cover;
}
</style>
