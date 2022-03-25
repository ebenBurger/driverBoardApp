<template>
    <div>
        <b-navbar class="navbar">
            <b-navbar-brand>
                Atrax Logistics    
            </b-navbar-brand>
            <div>
                <b-navbar-nav>
                    <router-link exact-active-class="active" to="/office">
                        <font-awesome-icon icon="fa-building" />
                        Offices
                    </router-link>
                    <router-link exact-active-class="active" to="/">
                        <font-awesome-icon icon="fa-home" />
                        Vehicle
                    </router-link>
                    <router-link exact-active-class="active" to="/contact">
                        <font-awesome-icon icon="fa-address-book" />
                        Contacts
                    </router-link>
                </b-navbar-nav>
            </div>
        </b-navbar>
    </div>
</template>

<script>
export default {
    data: () => ({}),
    beforeCreate() {
    },
    created() {
    },
    beforeMount() {
    },
    mounted() {
    },
    beforeUpdate() {
    },
    updated() {
    },
    methods: {},
    computed: {},
}
</script>

<style scoped>
.navbar {
    display: flex;
    justify-content: space-between;
}

a {
    color: black;
    margin: 0 0.3rem;
    background: white;
    padding: 0.1rem 0.4rem;
    border-radius: 12px;
}

ul a:hover {
    color: white;
    text-decoration: none;
    background: blue;
    padding: 0.1rem 0.4rem;
    border-radius: 12px;
}

.active {
    color: white;
    text-decoration: none;
    background: blue;
    padding: 0.1rem 0.4rem;
    border-radius: 12px;
}
</style>