import layout from "@/views/largeScreen/layout";

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
        name: 'layout',
        component: layout,
        children: [
            {
                path: '/',
                name: 'vehicleMain',
                component: vehicleMain,
            },
            {
                path: '/contact',
                name: 'contact',
                component: contact,
            },
            {
                path: '/office',
                name: 'officeMain',
                component: officeMain,
            },
            {
                path: '/driver',
                name: 'driverMain',
                component: driverMain,
            },
        ]
    },
    // additional vehicle pages
    {
        path: '/addVehicle',
        name: 'addVehicle',
        component: createVehicle,
    },
    {
        path: '/editVehicle',
        name: 'editVehicle',
        component: editVehicle,
    },
    
    //additional Office pages
    {
        path: '/addOffice',
        name: 'addOffice',
        component: createOffice,
    },
    {
        path: '/editOffice',
        name: 'editOffice',
        component: editOffice,
    },

    //additional Driver pages
    {
        path: '/addDriver',
        name: 'addDriver',
        component: createDriver,
    },
    {
        path: '/editDriver',
        name: 'editDriver',
        component: editDriver,
    },

    //additional Contact pages
    {
        path: '/addContact',
        name: 'addContact',
        component: createContact,
    },
    {
        path: '/editContact',
        name: 'editContact',
        component: editContact,
    },
]  