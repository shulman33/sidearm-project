<template>
    <v-navigation-drawer
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
