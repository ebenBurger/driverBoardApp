import layout from "@/views/largeScreen/layout";
//vehicle
import main from "@/views/largeScreen/vehicles/main";
import viewVehicle from "@/views/largeScreen/vehicles/viewVehicle";
import createVehicle from "@/views/largeScreen/vehicles/createVehicle";

//contact
import contacts from "@/views/largeScreen/contacts";

export default [
    {
        path: '/',
        name: 'layout',
        component: layout,
        children: [
            {
                path: '/',
                name: 'main',
                component: main,
            },
            {
                path: '/contacts',
                name: 'contacts',
                component: contacts,
            },
            {
                path: '/addVehicle',
                name: 'addVehicle',
                component: createVehicle,
            },
            {
                path: '/viewVehicle',
                name: 'viewVehicle',
                component: viewVehicle,
            },
        ]
    }
]  