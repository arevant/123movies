import React from 'react';
import * as PrimeReact from 'primereact/carousel';
import './carousel.css';

const Carousel: any = ({
    items,
    header,
    itemTemplate
}) => {
    const responsiveOptions = [
        {
            breakpoint: '1024px',
            numVisible: 3,
            numScroll: 3
        },
        {
            breakpoint: '600px',
            numVisible: 2,
            numScroll: 2
        },
        {
            breakpoint: '480px',
            numVisible: 1,
            numScroll: 1
        }
    ];

    return (
        <div className={'carousel'}>
            {items && items.length > 0 ?
                <PrimeReact.Carousel value={items} numVisible={3} numScroll={3} responsiveOptions={responsiveOptions}
                    itemTemplate={itemTemplate} header={<h5 className={'h5'}>{header}</h5>} />
                :
                <div>
                    <h5 className={'h5'}>{header}</h5>
                    No movies found. Update your filter/search criteria.
                </div>
            }
        </div>
    )
}

export default Carousel;