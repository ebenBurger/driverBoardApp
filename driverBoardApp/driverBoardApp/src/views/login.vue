<template>
    <div>
        <b-row align-h="center" align-v="center" class="full-height  login-container mb-0">
            <b-col cols="3">
                <b-card class="mb-2">
                    <b-card-header>
<!--                        <img src="@/assets/nextecLogo.png" alt="" class="img-to-fit">-->
                    </b-card-header>
                    <b-card-text>
                        <b-row class="mb-0 px-0">
<!--                            <b-col cols="12" class="px-0 mb-2"  v-for="(item, index) in messages" :key ="index">-->
<!--                                <b-alert show dismissible :variant="item.type">{{item.message}}</b-alert>-->
<!--                            </b-col>-->
                            <b-col cols="12" class="px-0">
                                <label>Username</label>
                                <b-form-input v-model="username"></b-form-input>
                            </b-col>
                            <b-col cols="12" class="px-0 mt-2">
                                <label>Password</label>
                                <b-form-input v-model="password" type="password"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row align-h="center" class="mx-0 mb-0">
                            <b-button class="mt-3 primary" size="sm" :variant="filled" block squared>
                                <b-spinner small v-if="isLoading"></b-spinner>
                                Login
                            </b-button>
                        </b-row>
                        <b-row class="mx-0">
                            <b-button class="mt-3 primary-no-border" size="sm" variant="outline-primary" block squared>
                                Forgot Password?
                            </b-button>
                        </b-row>
                    </b-card-text>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>

<script>
export default {
    data: () => ({
        state: 'login',
        showErrors: false,
        errors: [],
        username: null,
        password: null,
        email: null,
        isLoading: false
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