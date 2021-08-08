import React from 'react';
import * as PrimeReact from 'primereact/button';

const Button: any = ({
    label = '',
    onClick,
}) => {

    return (
        <div>
            <PrimeReact.Button
                onClick={onClick}
                label={label}
            />
        </div>
    )
}

export default Button;