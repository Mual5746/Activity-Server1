import { Grid, Header } from "semantic-ui-react";
import PhotoUploadWidgetDropzone from "./PhotoWidgetDropzone";


export default function PhotoUploadWidget (){
    return (
        < Grid>
            <Grid.Column width={4}>
                < Header sub color="teal" content="step 1 Add " />
                <PhotoUploadWidgetDropzone />
            </Grid.Column>
            <Grid.Column width={1}/>
            <Grid.Column width={4}>
                < Header sub color="teal" content="step 2 Add " />
            </Grid.Column>
            <Grid.Column width={1}/>
            <Grid.Column width={4}>
                < Header sub color="teal" content="step 3 Add " />
            </Grid.Column>
        </Grid>
    )
}