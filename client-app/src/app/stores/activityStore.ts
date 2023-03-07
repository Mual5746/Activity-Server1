import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import {Activity} from "../models/activity";
import {v4 as uuid} from 'uuid';

export  default class ActivityStore {

   // activities : Activity []= [];
    activityRegistry = new Map<string, Activity>();
    selectedActivity : Activity | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = true;


    constructor(){        

        makeAutoObservable(this) // this line do the jobb for the three lines belowe
        /*
        makeObservable(this , {
            title: observable,
            setTitle: action
        })
        */
    }
    get activitiesByDate() {
        return Array.from(this.activityRegistry.values()).sort((a,b) => 
                Date.parse(a.date) - Date.parse(b.date));  
    }

    loadActivities = async () => {
        try {
            const activities = await agent.Activities.list(); //geting activity from our api 
            
                
            activities.forEach( activity => {  // looping through the activities 
            activity.date = activity.date.split('T')[0];
            //this.activities.push(activity); // line belowe insteed
            this.activityRegistry.set(activity.id, activity);

            })
            this.setLoadingInitial(false);         
            
        } catch (error) {
            console.log(error);   
            this.setLoadingInitial(false);
                     
        }        
        
    }
    setLoadingInitial = ( state : boolean ) => {
        this.loadingInitial = state;
    }

    selectActivity = (id: string) =>{
        //this.selectedActivity = this.activities.find(a =>a.id == id);
        this.selectedActivity = this.activityRegistry.get(id);
    }

    cancleSelectedActivity = () =>{
        this.selectedActivity = undefined;
    }
    openForm = (id? : string) =>{
        id? this.selectActivity(id) : this.cancleSelectedActivity();
        this.editMode = true; 
    }
    closeForm = () =>{
        this.editMode = false;
    }

    createActivity = async (activity: Activity) =>{
        this.loading = true;
        activity.id = uuid();

        try {
            await agent.Activities.create(activity);
            runInAction( () =>{
                //this.activities.push(activity);
                this.activityRegistry.set(activity.id, activity);
                this.selectedActivity = activity;
                this.editMode = false;
                this.loading = false;
            })
            
        } catch (error) {
            console.log(error);
            runInAction( () =>{
                this.loading = false;
            })            
        }
    }

    updateActivity = async (activity: Activity) => {
        this.loading = true;

        try {
            await agent.Activities.update(activity);
            runInAction ( () =>{
                //creats an aray by first removes the activities and then passes the activity
               //this.activities =[...this.activities.filter(a =>a.id !== activity.id), activity];                
               this.activityRegistry.set(activity.id, activity);
              // this.activities.push(activity); //to uppdate the selected activity in viewe bar

                this.selectedActivity = activity;
                this.editMode= false;
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction ( () =>{
                this.loading = false;
            })            
        }
    }

    deleteActivity =async (id : string) => { 
        this.loading = true;

        try {
            await agent.Activities.delete(id);
            runInAction ( () => {
                //this.activities =[...this.activities.filter(a =>a.id !== id)];  
                this.activityRegistry.delete(id);              
               //this.activities.pop( id); //to uppdate the selected activity in viewe bar
               if( this.selectedActivity?.id ===id) this.cancleSelectedActivity();
               this.loading = false;
            })
            
        } catch (error) {
            console.log(error);
            runInAction (() => {
                this.loading = false;
            })
            
        }
        
    }
}
