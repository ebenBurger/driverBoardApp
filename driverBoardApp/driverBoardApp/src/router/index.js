import layout from "@/views/layout";
import main from "@/views/main";

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
        ]
    }
]  