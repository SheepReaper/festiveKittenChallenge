<template>
  <div id="app">
    <div id="header-nav" class="nav-bars">
      <router-link to="/">Home</router-link> |
      <router-link to="/command">Command</router-link> |
      <router-link to="/queues">Manage Queues</router-link> |
      <router-link to="/files">File Manager</router-link>
    </div>
    <router-view/>
    <div
      id="footer-nav"
      class="nav-bars"
    >Listening Station 1.0 - {{ agentCount }} Agents Reporting - {{ pendingTaskCount }} Pending Tasks - {{ exfiltratedFileCount }} Files Collected</div>
  </div>
</template>

<script>
export default {
  name: 'App',
  data () {
    return {
      agentCount: 0,
      pendingTaskCount: 0,
      exfiltratedFileCount: 0
    }
  }
}
</script>

<style lang="scss">
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;

  .nav-bars{
    background: cornflowerblue;
    position: fixed;
    width: 100%;
    padding: 10px;
    color: white;
  }

  a{
    color: white;
    text-decoration: none;
  }
}

#header-nav{
  top: 0;
  left: 0;
}

#footer-nav {
  bottom: 0;
  left: 0;
}
</style>
