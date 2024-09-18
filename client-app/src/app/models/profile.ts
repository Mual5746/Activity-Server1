import { User } from "./user";
export interface Profile {
    username: string;
    displayName: string;
    image?: string;
    bio?: string;
    hostUsername?: string;
    isCancelled?: boolean;
    attendees?: Profile[]
}
export class Profile implements Profile {
    constructor(user: User) {
        this.username = user.username;
        this.displayName = user.displayName;
        this.image = user.image
    }
}