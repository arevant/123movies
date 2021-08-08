import React from 'react';
import Carousel from '../../uicomponents/carousel/carousel';
import { Link } from 'react-router-dom';

const Movie = ({ items, header }) => {
    const itemTemplate = (item) => {
        const routeParam = { pathname: `/detail/${item.id}`, state: { ...item } };
        return (
            <div className="product-item">
                <div className="product-item-content">
                    <Link to={routeParam}>
                        <div className="p-mb-3">
                            <img src={item.poster} alt={'Not found'} className="product-image" />
                        </div>
                        <h4 className="mt-3">{item.title}</h4>
                    </Link>
                </div>
            </div>
        );
    }
    return (
        <>
            <Carousel items={items} header={header} itemTemplate={itemTemplate} />
        </>)
}

export default Movie;