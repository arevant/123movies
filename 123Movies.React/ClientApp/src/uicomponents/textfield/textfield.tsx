import React from 'react';
import * as PrimeReact from 'primereact/inputtext';
import * as PrimeReact2 from 'primereact/password';

const TextField: any = ({
    label = '',
    input,
    type = 'text',
    placeholder = ''
}) => {
    const onChange = (event: any) => {
        input.onChange(event.target.value)
    }

    return (
        <>
            {type === 'text' && <div className="p-float-label">
                <PrimeReact.InputText
                    id="in"
                    placeholder={placeholder}
                    onChange={onChange} />
                <label htmlFor="in">{label}</label>
            </div>}
            {type === 'password' && <div className="p-float-label">
                <PrimeReact2.Password
                    id="pw"
                    placeholder={placeholder}
                    onChange={onChange}
                    toggleMask />
                <label htmlFor="pw">{label}</label>
            </div>}
        </>
    )
}

export default TextField