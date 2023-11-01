import Pagination from './Pagination';
import { Spinner } from '../../components';
import ContactDataTable from './ContactTable';
import { useParams } from 'react-router-dom';
import { useEffect, type FunctionComponent } from 'react';
import { useAppSelector, useAppDispatch } from '../../store';
import { getContactDatasAsync, type ContactData } from '../../store/contactSlice';

const FetchData: FunctionComponent = () => {
  const dispatch = useAppDispatch();
    const { pageIndex: pageIndexDefault = '0' } = useParams();
    const intNextPageIndex = parseInt(pageIndexDefault, 10);
    const isLoading = useAppSelector<boolean>((state) => state.contact.isLoading);
    const contactdatas = useAppSelector<ContactData[]>((state) => state.contact.contactDatas);
    const pageIndex = useAppSelector<number>((state) => state.contact.pageIndex);

  useEffect(() => {
    if (pageIndex !== intNextPageIndex) {
        dispatch(getContactDatasAsync(intNextPageIndex));
    }
  }, [dispatch, pageIndex, intNextPageIndex]);

  return (
    <div className="section">
      <div className="container">
        <h3 className="title is-3">
          Contacts
        </h3>
        <div className="box container-box">
          <h3 className="title is-4">
            Contact List
          </h3>
          <h5 className="subtitle is-5">
            List the amount of contact that is specify in a json file on the server
          </h5>
          <Spinner isLoading={isLoading} />
                  <ContactDataTable contactDatas={contactdatas} />
                  <Pagination pageIndex={pageIndex} />
        </div>
      </div>
    </div>
  );
};

export default FetchData;
