<template>
  <v-app-bar
        color="#26547C"
        prominent
      >
        <v-app-bar-nav-icon color="white" variant="text" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>

        <v-toolbar-title style="color: white">YU CMS</v-toolbar-title>

        <v-spacer></v-spacer>

        <v-btn variant="text" color="white" icon="mdi-magnify"></v-btn>

        <v-btn variant="text" color="white" icon="mdi-filter"></v-btn>

        <v-btn variant="text" color="white" icon="mdi-dots-vertical"></v-btn>
      </v-app-bar>
    <v-navigation-drawer
    v-model="drawer"
      color="#26547C"
      theme="dark"
    >
      <v-list nav>
        <v-list-item v-for="(option, index) in options" 
                :key="index" 
                @click="navigateTo(option)"
                style="color: #FCFCFC;">{{ option }}</v-list-item>
      </v-list>

    </v-navigation-drawer>
</template>
  
<script setup>
  import { ref, reactive } from 'vue'
  import { useRouter } from 'vue-router'

  const router = useRouter()
  
  let drawer = ref(false) // drawer state

  const navigateTo = (option) => {
    const routeName = option.toLowerCase().replace(' ', '-')
    router.push(`/${routeName}`)
  }

  const options = reactive([
    "App Bar", 
    "Main",
    "Headlines", 
    "Bottom Banner", 
    "Slideshow", 
    "Secondary Banner",
    "Footer"
  ])
</script>
