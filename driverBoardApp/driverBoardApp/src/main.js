import Vue from 'vue';
import App from './App.vue';
import VueRouter from "vue-router";
import Routes from './router/index'
import VueMq from "vue-mq";
import store from "@/store";
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faAddressBook, faHome } from '@fortawesome/free-solid-svg-icons'

import { BootstrapVue, IconsPlugin } from "bootstrap-vue";

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import './style.scss'

Vue.config.productionTip = false;

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(VueRouter)
Vue.use(VueMq, {
    breakpoints: {
        mobile: 450,
        tablet: 860,
        laptop: 999,
        desktop: Infinity,
    }
})

const router = new VueRouter({
    routes : Routes,
    mode: 'history'
})

Vue.filter('dateTimeFilter', function (value) {
    if (!value) return ''
    let localeValue = new Date(value)
    let response = localeValue.toLocaleDateString() + ' ' + localeValue.getHours().toString().padStart(2, '0') + ':' + localeValue.getMinutes().toString().padStart(2, '0')
    return response
})

//FA icons
library.add( faHome, faAddressBook )
Vue.component('font-awesome-icon', FontAwesomeIcon)


fetch('/config.json')
    .then(response => response.json())
    .then(config => {
        new Vue({
            data: () => ({
                urlConfig : config
            }),
            el: '#app',
            render: h => h(App),
            router,
            store,
        })
    })
