import { createBrowserRouter, RouteObject } from 'react-router-dom';
import ActivityDashboard from '../../Features/activities/dashboard/ActivityDashboard';
import ActivityDetails from '../../Features/activities/datails/ActivityDetails';
import ActivityForm from '../../Features/activities/form/ActivityForm';
import HomePage from '../../Features/home/HomePage';
import App from '../layout/App';

export const routes: RouteObject [] = [
    {
        path: '/',
        element: <App />,
        children: [
            {path: '', element: <HomePage /> },
            {path: 'activities', element: <ActivityDashboard /> },
            {path: 'activities/:id', element: <ActivityDetails /> },
            {path: 'createActivity', element: <ActivityForm /> }
        ]
    }
]

export const router = createBrowserRouter(routes);