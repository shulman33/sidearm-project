<script setup>
import { RouterLink, RouterView } from 'vue-router'
import SidebarNav from './components/SidebarNav.vue'
</script>

<template >
  <v-app >
    <SidebarNav />
    <v-main >
      <RouterView />
    </v-main>
  </v-app>
</template>


