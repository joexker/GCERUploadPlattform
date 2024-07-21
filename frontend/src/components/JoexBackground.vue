<script setup>

</script>

<template>
  <div class="joexbackground">
    <img src="./icons/joeker_big.jpg">
  </div>

</template>

<style scoped>

.joexbackground {
  background-size: cover;
  position: fixed;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  opacity: 0.5;
}

.joexbackground img {
  width: 100%;
  height: 100%;
  object-fit: cover;
  position: absolute;
  top: 0;
  left: 0
}
</style>