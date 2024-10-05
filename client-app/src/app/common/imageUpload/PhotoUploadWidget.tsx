import { Button, Grid, Header } from "semantic-ui-react";
import PhotoUploadWidgetDropzone from "./PhotoWidgetDropzone";
import { useEffect, useState } from "react";
import PhotoWidgetCropper from "./PhotoWidgetCropper";


export default function PhotoUploadWidget (){
    const [files, setFiles] = useState<any>([]);
    const [cropper, setCropper] = useState<Cropper>();

    function onCrop() {
        if (cropper) {
            cropper.getCroppedCanvas().toBlob(blob => console.log(blob!))
        }
    }

    useEffect(() => {
        return () => {
            files.forEach((file: any) => URL.revokeObjectURL(file.preview))
        }
    }, [files]);

    return (
        < Grid>
            <Grid.Column width={4}>
                < Header sub color="teal" content="step 1 Add " />
                <PhotoUploadWidgetDropzone setFiles={setFiles} />
            </Grid.Column>
            <Grid.Column width={1}/>
            <Grid.Column width={4}>
                < Header sub color="teal" content="step 2 Add " />
                {files && files.length > 0 &&
                        <PhotoWidgetCropper setCropper={setCropper} imagePreview={files[0].preview} />
                    }
            </Grid.Column>
            <Grid.Column width={1}/>
            <Grid.Column width={4}>
                < Header sub color="teal" content="step 3 Add " />
                { files && files.length > 0 &&
                <>
                 <div className="img-preview" style={{ minHeight: 200, overflow: 'hidden' }} />
                <Button.Group widths={2}>
                        <Button  onClick={onCrop} positive icon='check' />
                        <Button  onClick={() => setFiles([])} icon='close' />
                    </Button.Group>
                </>
                
                }
            </Grid.Column>
        </Grid>
    )
}