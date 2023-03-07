import React, { useEffect } from 'react';
import { Container} from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../Features/activities/dashboard/ActivityDashboard';
import LoadingComponent from './LoadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';

function App() {
  const {activityStore} =  useStore();

  

  useEffect(() => {
    //axios.get<Activity[]>('http://localhost:5000/api/activities')

    /* //removing after using mobx
    agent.Activiities.list().then(response =>{
      let activities: Activity[] = [];
      response.forEach( activity => {
        activity.date = activity.date.split('T')[0];
        activities.push(activity);
      })
      setActivities(activities);
      setLoading(false);
    }) */

    activityStore.loadActivities();
    
  }, [activityStore ])
/*
  //these method defines in activityStore.ts
  function handleSelectActivity(id: string){
    setSelectedActivity(activities.find(x =>x.id === id)); 
  }
  
  function handleCancelSelectedActivity(){
    setSelectedActivity(undefined);
  }

  function handleFormOpen(id?: string){
    id ?  handleSelectActivity(id) : handleCancelSelectedActivity ();
    setEditMode(true);
  }
  function handleFormClose(){
    setEditMode(false);
  }
   */

  //using mobx, removes 
  /*
  function handleCreateOrEditActivity(activity: Activity ){
    setSubmitting(true);
    if (activity.id){
      agent.Activiities.update(activity).then( () => {
        setActivities([...activities.filter(x => x.id !== activity.id), activity])
        setSelectedActivity(activity);
        setEditMode(false);
        setSubmitting(false);
      })
    } else {
      activity.id = uuid();
      agent.Activiities.create(activity).then( () => {
        setActivities([...activities, activity])
        setSelectedActivity(activity);
        setEditMode(false);
        setSubmitting(false);
      } )
    }
  }
  */
  /*
  function handleDeleteActivity(id: string){
    setSubmitting(true);
    agent.Activities.delete(id).then( () =>{
      setActivities([...activities.filter(x=>x.id !==id)]);
      setSubmitting(false);
    })
  }
  */
  if (activityStore.loadingInitial) return < LoadingComponent content = 'Loading App' />

  return (
    < >
       <NavBar />
       <Container style={{marginTop : "7em"}} >
          <ActivityDashboard />
       </Container>        
    </>
  );
}

export default observer(App);
