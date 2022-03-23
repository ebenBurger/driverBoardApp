<template>
    <div>
        <mq-layout mq="mobile">
            <h1>Coming soon</h1>
        </mq-layout>
        <mq-layout mq="tablet+" class="layout">
            <div>
                <Nav />
                <br />
                <router-view></router-view>
            </div>
        </mq-layout>
    </div>
</template>

<script>

import Nav from "@/components/largeScreen/nav";
import {mapMutations} from "vuex";

export default {
    ...mapMutations(['setApiUrl']),
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