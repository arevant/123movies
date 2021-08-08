import React from 'react';
import { Galleria } from 'primereact/galleria';

const Gallery: any = ({
    images
}) => {
    const responsiveOptions = [
        {
            breakpoint: '1024px',
            numVisible: 5
        },
        {
            breakpoint: '768px',
            numVisible: 3
        },
        {
            breakpoint: '560px',
            numVisible: 1
        }
    ];

    const itemTemplate = (item) => {
        return <img src={item} alt={"Invalid image"} style={{ width: '100%', display: 'block' }} />;
    }

    const thumbnailTemplate = (item) => {
        return <img src={item} alt={"Invalid image"} style={{ display: 'block' }} />;
    }
    return (
        <div className="">
            <Galleria value={images} responsiveOptions={responsiveOptions} numVisible={images?.length} circular style={{ maxWidth: '640px' }}
                showItemNavigators={false} item={itemTemplate} thumbnail={thumbnailTemplate} showThumbnails={false} showIndicators/>
        </div>
    )
}

export default Gallery;