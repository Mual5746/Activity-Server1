import React from 'react';
import { useField } from "formik";
import { Form, Label } from "semantic-ui-react";
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'; // Se till att inkludera CSS för DatePicker

interface MyDateInputProps {
    name: string;
    placeholderText?: string;
    showTimeSelect?: boolean;
    timeCaption?: string;
    dateFormat?: string;
}

export default function MyDateInput(props: MyDateInputProps) {
    const [field, meta, helpers] = useField(props.name);

    return (
        <Form.Field error={meta.touched && !!meta.error}>
            <DatePicker
                {...field}
                {...props} // Sprider både field och props, vilket låter DatePicker hantera dem
                selected={(field.value && new Date(field.value)) || null}
                onChange={(value: Date | null) => helpers.setValue(value)}
            />
            {meta.touched && meta.error ? (
                <Label basic color='red'>{meta.error}</Label>
            ) : null}
        </Form.Field>
    );
}
