import React from 'react';
import * as PrimeReact from 'primereact/dropdown';

const Dropdown: any = ({
    label = '',
    input,
    meta,
    options = []
}) => {
    const showError = (meta.dirty || meta.submitFailed) && meta.error ? true : false;

    const onChange = (event: any) => {
        input.onChange(event.target.value)
    }

    return (
        <div>
            <div>{label}</div>
            <PrimeReact.Dropdown
                options={options}
                onChange={onChange}
                value={input.value}
            />
        </div>
    )
}

export default Dropdown;