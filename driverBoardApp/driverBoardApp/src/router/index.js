import layout from "@/views/largeScreen/layout";

//login
import login from "@/views/login";

//vehicle
import vehicleMain from "@/views/largeScreen/vehicles/vehicleMain";
import createVehicle from "@/views/largeScreen/vehicles/createVehicle";
import editVehicle from "@/views/largeScreen/vehicles/editVehicle";

//offices
import officeMain from "@/views/largeScreen/office/officeMain";
import createOffice from "@/views/largeScreen/office/createOffice";
import editOffice from "@/views/largeScreen/office/editOffice";

//driver
import driverMain from "@/views/largeScreen/driver/driverMain";
import createDriver from "@/views/largeScreen/driver/createDriver";
import editDriver from "@/views/largeScreen/driver/editDriver";

//contact
import contact from "@/views/largeScreen/contact/contact";
import createContact from "@/views/largeScreen/contact/createContact";
import editContact from "@/views/largeScreen/contact/editContact";

export default [
    {
        path: '/',
        name: 'login',
        component: login,
        meta: {
            requiresAuth: false
        }
    },
    {
        path: '/',
        name: 'layout',
        component: layout,
        children: [
            {
                path: '/vehicle',
                name: 'vehicleMain',
                component: vehicleMain,
                meta: {
                    requiresAuth: true
                }
            },
            {
                path: '/contact',
                name: 'contact',
                component: contact,
                meta: {
                    requiresAuth: true
                }
            },
            {
                path: '/office',
                name: 'officeMain',
                component: officeMain,
                meta: {
                    requiresAuth: true
                }
            },
            {
                path: '/driver',
                name: 'driverMain',
                component: driverMain,
                meta: {
                    requiresAuth: true
                }
            },
        ]
    },
    // additional vehicle pages
    {
        path: '/addVehicle',
        name: 'addVehicle',
        component: createVehicle,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: '/editVehicle',
        name: 'editVehicle',
        component: editVehicle,
        meta: {
            requiresAuth: true
        }
    },
    
    //additional Office pages
    {
        path: '/addOffice',
        name: 'addOffice',
        component: createOffice,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: '/editOffice',
        name: 'editOffice',
        component: editOffice,
        meta: {
            requiresAuth: true
        }
    },

    //additional Driver pages
    {
        path: '/addDriver',
        name: 'addDriver',
        component: createDriver,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: '/editDriver',
        name: 'editDriver',
        component: editDriver,
        meta: {
            requiresAuth: true
        }
    },

    //additional Contact pages
    {
        path: '/addContact',
        name: 'addContact',
        component: createContact,
        meta: {
            requiresAuth: true
        }
    },
    {
        path: '/editContact',
        name: 'editContact',
        component: editContact,
        meta: {
            requiresAuth: true
        }
    },
]  