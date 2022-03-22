<template>
    <div>
        <mq-layout mq="mobile">
            <h1>Coming soon</h1>
        </mq-layout>
        <mq-layout mq="tablet+">
            <div>
                <Nav />
                <router-view></router-view>
            </div>
        </mq-layout>
    </div>
</template>

<script>

import Nav from "@/components/nav";
export default {
    components: {Nav},
    data: () => ({}),
    beforeCreate() {},
    created() {
        this.$store.commit('setApiUrl', this.$root.urlConfig.api_url)
    },
    beforeMount() {},
    mounted() {},
    beforeUpdate() {},
    updated() {},
    methods: {},
    computed: {},
}
</script>

<style scoped>

</style>