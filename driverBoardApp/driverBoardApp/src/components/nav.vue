<template>
    <div>
        <div v-for="(option, index) in options" :model="selected" :key="index">
            <p>{{option.title}}</p>
            <p><font-awesome-icon icon='option.icon' /></p>
        </div>
    </div>
</template>

<script>
export default {
    data: () => ({
        selected: 1,
        options: [
            { id: 1, icon: "Home", title: "Home", color: 'black'},
            { id: 2, icon: "LayerGroup", title: "Category" },
            { id: 3, icon: "Cog", title: "Setting" },
            { id: 4, icon: "User", title: "Account", badge: 15 },
            { id: 5, icon: "Bell", title: "Notification" },
        ],
    }),
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


</style>