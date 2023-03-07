import { observe } from 'mobx';
import { observer } from 'mobx-react-lite';
import React from 'react'
import { Grid } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/store';
import ActivityDetails from '../datails/ActivityDetails';
import ActivityForm from '../form/ActivityForm';
import ActivitList from './ActivitList';


export default observer ( function ActivityDashboard( ) {
    
    const {activityStore} = useStore();
    const {selectedActivity, editMode} = activityStore;
    return (    
        <Grid>
            <Grid.Column width='10'>
                <ActivitList  />
            </Grid.Column>
            <Grid.Column width='6' >
                {selectedActivity && !editMode &&
                <ActivityDetails /> }
                { editMode &&
                <ActivityForm /> }
            </Grid.Column>
        </Grid>
    )
})