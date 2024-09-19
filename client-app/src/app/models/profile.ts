import { User } from "./user";


export interface IProfile {
    username: string;
    displayName: string;
    image?: string;
    bio?: string;
    hostUsername?: string;
    isCancelled?: boolean;
    attendees?: Profile[]
}

//added this class 
export class Profile implements IProfile {
    constructor(user: User) {
        this.username = user.username;
        this.displayName = user.displayName;
        this.image = user.image
    }

    username: string;
    displayName: string;
    image?: string;
    bio?: string;
}