import { memo } from 'react';
import { Link } from 'react-router-dom';
import type { ContactState } from '../../store/contactSlice';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

type PaginationProps = Pick<ContactState, 'pageIndex'>;

const Pagination = memo<PaginationProps>(({ pageIndex = 0 }) => (
  <p className="buttons pagination-group">
    <Link
      className="button is-info"
            to={`/contact/${pageIndex - 1}`}
    >
      <FontAwesomeIcon icon="angle-double-left" />
    </Link>
    <Link
      className="button is-info"
            to={`/contact/${pageIndex + 1}`}
    >
      <FontAwesomeIcon icon="angle-double-right" />
    </Link>
  </p>
));

Pagination.displayName = 'Pagination';

export default Pagination;