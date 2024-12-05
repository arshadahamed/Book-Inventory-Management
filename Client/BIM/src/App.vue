<template>
<div class="flex flex-col min-h-screen">
    <Header />
    <main class="flex-grow">
      <router-view />
    </main>
    <Footer/>
  </div>
</template>

<script>
import Header from './components/Header.vue';
import Footer from './components/Footer.vue';
import { RouterView } from 'vue-router';

export default {
  components: {
    Header,
    RouterView,
    Footer,
  },
   methods: {
    
  },
  data() {
    return {
      
  }
  },
  created() {
   
  },
};
</script>
