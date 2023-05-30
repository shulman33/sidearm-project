<template>
  <v-card>
    <v-layout>
      <v-navigation-drawer
        image="https://cdn.vuetifyjs.com/images/backgrounds/bg-2.jpg"
        permanent
        theme="dark"
      >
        <v-list nav>
          <v-list-item v-for="(option, index) in options" 
                  :key="index" 
                  @click="navigateTo(option)"
                  style="color: #FCFCFC;">{{ option }}</v-list-item>
          
        </v-list>
      </v-navigation-drawer>
      
    </v-layout>
  </v-card>
</template>
  
  <script setup>
    import { ref, reactive } from 'vue'
    import { useRouter } from 'vue-router'

    const router = useRouter()
    

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


  