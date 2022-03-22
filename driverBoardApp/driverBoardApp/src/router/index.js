import layout from "@/views/layout";
import main from "@/views/main";
import contacts from "@/views/contacts";

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
        ]
    }
]  