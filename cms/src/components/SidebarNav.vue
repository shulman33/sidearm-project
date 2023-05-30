<template>
    <v-card>

      <v-layout>
        
        <v-app-bar 
          color="#26547C"           
        >
            <v-app-bar-nav-icon 
              variant="text" 
              @click.stop="drawer = !drawer"
            ></v-app-bar-nav-icon>

            <v-toolbar-title style="color: #FFFFFF;">YU CMS</v-toolbar-title>
        </v-app-bar>
        
        <v-navigation-drawer
          v-model="drawer"
          temporary
          style="background-color: #26547C;"
        >
          <v-list-item
            title="Home Page Sections"
            style="color: white;"
          ></v-list-item>
  
          <v-divider></v-divider>
  
          <v-list density="compact" nav>
            <v-list-item 
              v-for="(option, index) in options" 
                  :key="index" 
                  @click="navigateTo(option)"
                  style="color: #FCFCFC;"
                  >
                  {{ option }}
            </v-list-item>
          </v-list>
        </v-navigation-drawer>
        <v-main style="height: 100vh; background-color: #FCFCFC;">
          <div class="d-flex justify-center align-center w-100 h-100">
            <slot>

            </slot>
          </div>
        </v-main>
      </v-layout>
    </v-card>
  </template>
  
  <script setup>
    import { ref, reactive } from 'vue'
    import { useRouter } from 'vue-router'

    const router = useRouter()
    const drawer = ref(false)

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


  